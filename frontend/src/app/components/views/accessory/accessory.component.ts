import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Accessory } from 'src/app/models/accessory.model';
import { AccessoryService } from 'src/app/services/accessory.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { EditDialogComponent } from '../../shared/edit-dialog/edit-dialog.component';
import { DialogType } from 'src/app/models/enums/dialog-type';
import { catchError, of, switchMap, tap, throwError } from 'rxjs';
import { DeleteDialogComponent } from '../../shared/delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-accessory',
  templateUrl: './accessory.component.html',
  styleUrls: ['./accessory.component.scss']
})
export class AccessoryComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  @Input() accessory: Accessory;
  @Input() isEditMode: boolean = false;
  @Output() editEvent = new EventEmitter<Accessory>();

  displayedColumns = ["id", "description", "isActive", "actions"];
  dataSource!: MatTableDataSource<Accessory>;

  form = new FormGroup({
    description: new FormControl('', [Validators.required]),
    isActive: new FormControl(false)
  });

  constructor(
    private dialog: MatDialog,
    private accessoryService: AccessoryService
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
    this.form.controls['description'].setValue(this.accessory.description);
    this.form.controls['isActive'].setValue(this.accessory.isActive);
  }

  clearForm(): void {
    this.form.controls['description'].setValue('');
    this.form.controls['isActive'].setValue(false);

    this.form.controls['description'].setErrors(null);
    this.form.controls['isActive'].setErrors(null);
  }

  emitEditEvent(): void {
    this.accessory.description = this.form.controls['description'].value!;
    this.accessory.isActive = this.form.controls['isActive'].value!;

    this.editEvent.emit(this.accessory);
  }

  getAll(): void {
    this.accessoryService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Accessory>(result);
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  create(): void {
    const accessory = {} as Accessory;

    accessory.description = this.form.controls['description'].value!;
    accessory.isActive = this.form.controls['isActive'].value!;

    this.accessoryService.create(accessory).subscribe((result) => {
      if (result) {
        this.clearForm();
        this.getAll();
      }
    });
  }

  update(accessory: Accessory): void {
    const dialogRef = this.dialog.open(EditDialogComponent, {
      width: '600px',
      data: { model: accessory, dialogType: DialogType.EditAccessory }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.accessoryService.update(accessory, accessory.id)
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

  delete(accessory: Accessory): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '600px',
      data: {
        type: 'accessory',
        text: accessory.description,
        dialogType: DialogType.EditAccessory
      }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.accessoryService.delete(accessory.id)
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
