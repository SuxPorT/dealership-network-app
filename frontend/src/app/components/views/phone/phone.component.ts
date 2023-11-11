import { ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { switchMap, catchError, throwError, of, tap } from 'rxjs';
import { DialogType } from 'src/app/models/enums/dialog-type';
import { Phone } from 'src/app/models/phone.model';
import { PhoneService } from 'src/app/services/phone.service';
import { DeleteDialogComponent } from '../../shared/delete-dialog/delete-dialog.component';
import { EditDialogComponent } from '../../shared/edit-dialog/edit-dialog.component';

@Component({
  selector: 'app-phone',
  templateUrl: './phone.component.html',
  styleUrls: ['./phone.component.scss']
})
export class PhoneComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  @Input() phone: Phone;
  @Input() isEditMode: boolean = false;
  @Output() editEvent = new EventEmitter<Phone>();

  displayedColumns = ["id", "number", "ownerCpfCnpj", "isActive", "actions"];
  dataSource!: MatTableDataSource<Phone>;

  form = new FormGroup({
    number: new FormControl('', [Validators.required]),
    ownerCpfCnpj: new FormControl('', [Validators.required]),
    isActive: new FormControl(false)
  });

  constructor(
    private dialog: MatDialog,
    private changeDetectorRef: ChangeDetectorRef,
    private phoneService: PhoneService
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
    this.form.controls['number'].setValue(this.phone.number);
    this.form.controls['ownerCpfCnpj'].setValue(this.phone.ownerCpfCnpj);
    this.form.controls['isActive'].setValue(this.phone.isActive);
  }

  clearForm(): void {
    this.form.controls['number'].setValue('');
    this.form.controls['ownerCpfCnpj'].setValue('');
    this.form.controls['isActive'].setValue(false);

    this.form.controls['number'].setErrors(null);
    this.form.controls['ownerCpfCnpj'].setErrors(null);
    this.form.controls['isActive'].setErrors(null);
  }

  emitEditEvent(): void {
    this.phone.number = this.form.controls['number'].value!;
    this.phone.ownerCpfCnpj = this.form.controls['ownerCpfCnpj'].value!;
    this.phone.isActive = this.form.controls['isActive'].value!;

    this.editEvent.emit(this.phone);
  }

  getAll(): void {
    this.phoneService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Phone>(result);
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  create(): void {
    const phone = {} as Phone;

    phone.number = this.form.controls['number'].value!;
    phone.ownerCpfCnpj = this.form.controls['ownerCpfCnpj'].value!;
    phone.isActive = this.form.controls['isActive'].value!;

    this.phoneService.create(phone).subscribe((result) => {
      if (result) {
        this.clearForm();
        this.getAll();
      }
    });
  }

  update(phone: Phone): void {
    const dialogRef = this.dialog.open(EditDialogComponent, {
      width: '600px',
      data: { model: phone, dialogType: DialogType.EditPhone }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.phoneService.update(phone, phone.id)
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
          this.dataSource.data = [...this.dataSource.data];
          this.changeDetectorRef.detectChanges();;
        })
      ).subscribe(
        (_result) => { },
        (_error) => { }
      );
  }

  delete(phone: Phone): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '600px',
      data: {
        type: 'phone',
        text: phone.number,
        dialogType: DialogType.EditPhone
      }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.phoneService.delete(phone.id)
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
          this.dataSource.data = [...this.dataSource.data];
          this.changeDetectorRef.detectChanges();;
        })
      ).subscribe(
        (_result) => { },
        (_error) => { }
      );
  }

}
