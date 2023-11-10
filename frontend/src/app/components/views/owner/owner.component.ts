import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { switchMap, catchError, throwError, of, tap } from 'rxjs';
import { DialogType } from 'src/app/models/enums/dialog-type';
import { Owner } from 'src/app/models/owner.model';
import { OwnerService } from 'src/app/services/owner.service';
import { DeleteDialogComponent } from '../../shared/delete-dialog/delete-dialog.component';
import { EditDialogComponent } from '../../shared/edit-dialog/edit-dialog.component';

@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrls: ['./owner.component.scss']
})
export class OwnerComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  @Input() owner: Owner;
  @Input() isEditMode: boolean = false;
  @Output() editEvent = new EventEmitter<Owner>();

  displayedColumns = [
    "cpfCnpj", "hiringType", "name", "birthDate",
    "city", "UF", "CEP", "isActive", "actions"
  ];
  dataSource!: MatTableDataSource<Owner>;

  form = new FormGroup({
    cpfCnpj: new FormControl('', [Validators.required]),
    hiringType: new FormControl('', [Validators.required]),
    name: new FormControl('', [Validators.required]),
    birthDate: new FormControl(new Date(), [Validators.required]),
    city: new FormControl('', [Validators.required]),
    uf: new FormControl('', [Validators.required]),
    cep: new FormControl('', [Validators.required]),
    isActive: new FormControl(false)
  });

  constructor(
    private dialog: MatDialog,
    private ownerService: OwnerService
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
    this.form.controls['cpfCnpj'].setValue(this.owner.cpfCnpj);
    this.form.controls['hiringType'].setValue(this.owner.hiringType);
    this.form.controls['name'].setValue(this.owner.name);
    this.form.controls['birthDate'].setValue(this.owner.birthDate);
    this.form.controls['city'].setValue(this.owner.city);
    this.form.controls['uf'].setValue(this.owner.uf);
    this.form.controls['cep'].setValue(this.owner.cep);
    this.form.controls['isActive'].setValue(this.owner.isActive);
  }

  clearForm(): void {
    this.form.controls['cpfCnpj'].setValue('');
    this.form.controls['hiringType'].setValue('');
    this.form.controls['name'].setValue('');
    this.form.controls['birthDate'].setValue(null);
    this.form.controls['city'].setValue('');
    this.form.controls['uf'].setValue('');
    this.form.controls['cep'].setValue('');
    this.form.controls['isActive'].setValue(false);

    this.form.controls['cpfCnpj'].setErrors(null);
    this.form.controls['hiringType'].setErrors(null);
    this.form.controls['name'].setErrors(null);
    this.form.controls['birthDate'].setErrors(null);
    this.form.controls['city'].setErrors(null);
    this.form.controls['uf'].setErrors(null);
    this.form.controls['cep'].setErrors(null);
    this.form.controls['isActive'].setErrors(null);
  }

  emitEditEvent(): void {
    this.owner.cpfCnpj = this.form.controls['cpfCnpj'].value!;
    this.owner.hiringType = this.form.controls['hiringType'].value!;
    this.owner.name = this.form.controls['name'].value!;
    this.owner.birthDate = this.form.controls['birthDate'].value!;
    this.owner.city = this.form.controls['city'].value!;
    this.owner.uf = this.form.controls['uf'].value!;
    this.owner.cep = this.form.controls['cep'].value!;
    this.owner.isActive = this.form.controls['isActive'].value!;

    this.editEvent.emit(this.owner);
  }

  getAll(): void {
    this.ownerService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Owner>(result);
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  create(): void {
    const owner = {} as Owner;

    owner.cpfCnpj = this.form.controls['cpfCnpj'].value!;
    owner.hiringType = this.form.controls['hiringType'].value!;
    owner.name = this.form.controls['name'].value!;
    owner.birthDate = this.form.controls['birthDate'].value!;
    owner.city = this.form.controls['city'].value!;
    owner.uf = this.form.controls['uf'].value!;
    owner.cep = this.form.controls['cep'].value!;
    owner.isActive = this.form.controls['isActive'].value!;

    this.ownerService.create(owner).subscribe((result) => {
      if (result) {
        this.clearForm();
        this.getAll();
      }
    });
  }

  update(owner: Owner): void {
    const dialogRef = this.dialog.open(EditDialogComponent, {
      width: '600px',
      data: { model: owner, dialogType: DialogType.EditOwner }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.ownerService.update(owner, owner.cpfCnpj)
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

  delete(owner: Owner): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '600px',
      data: {
        type: 'phone',
        text: owner.cpfCnpj,
        dialogType: DialogType.EditPhone
      }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.ownerService.delete(owner.cpfCnpj)
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
