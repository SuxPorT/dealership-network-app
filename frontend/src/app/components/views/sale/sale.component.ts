import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { switchMap, catchError, throwError, of, tap } from 'rxjs';
import { DialogType } from 'src/app/models/enums/dialog-type';
import { Sale } from 'src/app/models/sale.model';
import { SaleService } from 'src/app/services/sale.service';
import { DeleteDialogComponent } from '../../shared/delete-dialog/delete-dialog.component';
import { EditDialogComponent } from '../../shared/edit-dialog/edit-dialog.component';

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.scss']
})
export class SaleComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  @Input() sale: Sale;
  @Input() isEditMode: boolean = false;
  @Output() editEvent = new EventEmitter<Sale>();

  displayedColumns = [
    "id", "price", "vehicleChassisNumber",
    "sellerId", "isActive", "actions"
  ];
  dataSource!: MatTableDataSource<Sale>;

  form = new FormGroup({
    price: new FormControl(0, [Validators.required]),
    vehicleChassisNumber: new FormControl('', [Validators.required]),
    sellerId: new FormControl(0, [Validators.required]),
    isActive: new FormControl(false)
  });

  constructor(
    private dialog: MatDialog,
    private saleService: SaleService
  ) { }

  ngOnInit(): void {
    if (this.isEditMode) {
      this.fillForm();
    } else {
      this.getAll();
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
    this.form.controls['price'].setValue(this.sale.price);
    this.form.controls['vehicleChassisNumber'].setValue(this.sale.vehicleChassisNumber);
    this.form.controls['sellerId'].setValue(this.sale.sellerId);
    this.form.controls['isActive'].setValue(this.sale.isActive);
  }

  clearForm(): void {
    this.form.controls['price'].setValue(0);
    this.form.controls['vehicleChassisNumber'].setValue('');
    this.form.controls['sellerId'].setValue(0);
    this.form.controls['isActive'].setValue(false);

    this.form.controls['price'].setErrors(null);
    this.form.controls['vehicleChassisNumber'].setErrors(null);
    this.form.controls['sellerId'].setErrors(null);
    this.form.controls['isActive'].setErrors(null);
  }

  emitEditEvent(): void {
    this.sale.price = this.form.controls['price'].value!;
    this.sale.vehicleChassisNumber = this.form.controls['vehicleChassisNumber'].value!;
    this.sale.sellerId = this.form.controls['sellerId'].value!;
    this.sale.isActive = this.form.controls['isActive'].value!;

    this.editEvent.emit(this.sale);
  }

  getAll(): void {
    this.saleService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Sale>(result);
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  create(): void {
    const sale = {} as Sale;

    sale.price = Number(this.form.controls['price'].value!);
    sale.vehicleChassisNumber = this.form.controls['vehicleChassisNumber'].value!;
    sale.sellerId = Number(this.form.controls['sellerId'].value!);
    sale.isActive = this.form.controls['isActive'].value!;

    this.saleService.create(sale).subscribe((result) => {
      if (result) {
        this.clearForm();
        this.getAll();
      }
    });
  }

  update(sale: Sale): void {
    const dialogRef = this.dialog.open(EditDialogComponent, {
      width: '600px',
      data: { model: sale, dialogType: DialogType.EditSale }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.saleService.update(sale, sale.id)
              .pipe(
                catchError((error) => {
                  this.getAll();
                  return throwError(() => new Error(error));
                })
              );
          } else {
            return of();
          }
        }),
        tap(() => {
          location.reload();
        })
      ).subscribe(
        (_result) => { },
        (_error) => { }
      );
  }

  delete(sale: Sale): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '600px',
      data: {
        type: 'sale',
        text: `Vehile ${sale.vehicleChassisNumber} for Seller ${sale.sellerId}`,
        dialogType: DialogType.EditSale
      }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.saleService.delete(sale.id)
              .pipe(
                catchError((error) => {
                  this.getAll();
                  return throwError(() => new Error(error));
                })
              );
          } else {
            return of();
          }
        }),
        tap(() => {
          location.reload();
        })
      ).subscribe(
        (_result) => { },
        (_error) => { }
      );
  }

}
