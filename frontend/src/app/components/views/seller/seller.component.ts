import { ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { switchMap, catchError, throwError, of, tap } from 'rxjs';
import { DialogType } from 'src/app/models/enums/dialog-type';
import { Seller } from 'src/app/models/seller.model';
import { SellerService } from 'src/app/services/seller.service';
import { DeleteDialogComponent } from '../../shared/delete-dialog/delete-dialog.component';
import { EditDialogComponent } from '../../shared/edit-dialog/edit-dialog.component';

@Component({
  selector: 'app-seller',
  templateUrl: './seller.component.html',
  styleUrls: ['./seller.component.scss']
})
export class SellerComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  @Input() seller: Seller;
  @Input() isEditMode: boolean = false;
  @Output() editEvent = new EventEmitter<Seller>();

  displayedColumns = ["id", "name", "baseSalary", "isActive", "actions"];
  dataSource!: MatTableDataSource<Seller>;

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    baseSalary: new FormControl(0, [Validators.required]),
    isActive: new FormControl(false)
  });

  constructor(
    private dialog: MatDialog,
    private changeDetectorRef: ChangeDetectorRef,
    private sellerService: SellerService
  ) { }

  ngOnInit(): void {
    if (this.isEditMode) {
      this.fillForm();
    } else {
      this.getSellers();
    }
  }

  sortChange(sortState: Sort) {
    if (sortState.direction) {
      this.sort.direction = sortState.direction;
      this.sort.active = sortState.active;
      this.dataSource.sort = this.sort;
    } else {
      this.dataSource.sort = null;
    }
  }

  onSubmit(): void {
    if (this.form.valid) {
      if (!this.isEditMode) {
        this.create();
      } else {
        this.emitEditEvent();
      }
    }
  }

  fillForm(): void {
    this.form.controls['name'].setValue(this.seller.name);
    this.form.controls['baseSalary'].setValue(this.seller.baseSalary);
    this.form.controls['isActive'].setValue(this.seller.isActive);
  }

  clearForm(): void {
    this.form.controls['name'].setValue('');
    this.form.controls['baseSalary'].setValue(0);
    this.form.controls['isActive'].setValue(false);

    this.form.controls['name'].setErrors(null);
    this.form.controls['baseSalary'].setErrors(null);
    this.form.controls['isActive'].setErrors(null);
  }

  emitEditEvent(): void {
    this.seller.name = this.form.controls['name'].value!;
    this.seller.baseSalary = this.form.controls['baseSalary'].value!;
    this.seller.isActive = this.form.controls['isActive'].value!;

    this.editEvent.emit(this.seller);
  }

  getSellers(): void {
    this.sellerService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Seller>(result);
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  create(): void {
    const seller = {} as Seller;

    seller.name = this.form.controls['name'].value!;
    seller.baseSalary = Number(this.form.controls['baseSalary'].value!);
    seller.isActive = this.form.controls['isActive'].value!;

    this.sellerService.create(seller).subscribe((result) => {
      if (result) {
        this.clearForm();
        this.getSellers();
      }
    });
  }

  update(seller: Seller): void {
    const dialogRef = this.dialog.open(EditDialogComponent, {
      width: '600px',
      data: { model: seller, dialogType: DialogType.EditSeller }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.sellerService.update(seller, seller.id)
              .pipe(
                catchError((error) => {
                  this.getSellers();
                  return throwError(() => new Error(error));
                })
              );
          } else {
            return of();
          }
        }),
        tap(() => {
          this.dataSource.data = [...this.dataSource.data];
          this.changeDetectorRef.detectChanges();
        })
      ).subscribe(
        (_result) => { },
        (_error) => { }
      );
  }

  delete(seller: Seller): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '600px',
      data: {
        type: 'seller',
        text: seller.name,
        dialogType: DialogType.EditAccessory
      }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.sellerService.delete(seller.id)
              .pipe(
                catchError((error) => {
                  this.getSellers();
                  return throwError(() => new Error(error));
                })
              );
          } else {
            return of();
          }
        }),
        tap(() => {
          this.dataSource.data = [...this.dataSource.data];
          this.changeDetectorRef.detectChanges();
        })
      ).subscribe(
        (_result) => { },
        (_error) => { }
      );
  }

}
