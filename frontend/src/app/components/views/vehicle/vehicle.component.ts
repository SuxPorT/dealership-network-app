import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { switchMap, catchError, throwError, of, tap } from 'rxjs';
import { DialogType } from 'src/app/models/enums/dialog-type';
import { Vehicle } from 'src/app/models/vehicle.model';
import { VehicleService } from 'src/app/services/vehicle.service';
import { DeleteDialogComponent } from '../../shared/delete-dialog/delete-dialog.component';
import { EditDialogComponent } from '../../shared/edit-dialog/edit-dialog.component';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.scss']
})
export class VehicleComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  @Input() vehicle: Vehicle;
  @Input() isEditMode: boolean = false;
  @Output() editEvent = new EventEmitter<Vehicle>();

  displayedColumns = [
    "chassisNumber", "model", "year", "color", "price",
    "mileage", "systemVersion", "ownerCpfCnpj", "isActive", "actions"
  ];
  dataSource!: MatTableDataSource<Vehicle>;

  form = new FormGroup({
    chassisNumber: new FormControl('', [Validators.required]),
    model: new FormControl('', [Validators.required]),
    year: new FormControl(0, [Validators.required]),
    color: new FormControl('', [Validators.required]),
    price: new FormControl(0, [Validators.required]),
    mileage: new FormControl(0, [Validators.required]),
    systemVersion: new FormControl('', [Validators.required]),
    ownerCpfCnpj: new FormControl('', [Validators.required]),
    isActive: new FormControl(false)
  });

  constructor(
    private dialog: MatDialog,
    private vehicleService: VehicleService
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
    this.form.controls['chassisNumber'].setValue(this.vehicle.chassisNumber);
    this.form.controls['model'].setValue(this.vehicle.model);
    this.form.controls['year'].setValue(this.vehicle.year);
    this.form.controls['color'].setValue(this.vehicle.color);
    this.form.controls['price'].setValue(this.vehicle.price);
    this.form.controls['mileage'].setValue(this.vehicle.mileage);
    this.form.controls['systemVersion'].setValue(this.vehicle.systemVersion);
    this.form.controls['ownerCpfCnpj'].setValue(this.vehicle.ownerCpfCnpj);
    this.form.controls['isActive'].setValue(this.vehicle.isActive);
  }

  clearForm(): void {
    this.form.controls['chassisNumber'].setValue('');
    this.form.controls['model'].setValue('');
    this.form.controls['year'].setValue(0);
    this.form.controls['color'].setValue('');
    this.form.controls['price'].setValue(0);
    this.form.controls['mileage'].setValue(0);
    this.form.controls['systemVersion'].setValue('');
    this.form.controls['ownerCpfCnpj'].setValue('');
    this.form.controls['isActive'].setValue(false);

    this.form.controls['chassisNumber'].setErrors(null);
    this.form.controls['model'].setErrors(null);
    this.form.controls['year'].setErrors(null);
    this.form.controls['color'].setErrors(null);
    this.form.controls['price'].setErrors(null);
    this.form.controls['mileage'].setErrors(null);
    this.form.controls['systemVersion'].setErrors(null);
    this.form.controls['ownerCpfCnpj'].setErrors(null);
    this.form.controls['isActive'].setErrors(null);
  }

  emitEditEvent(): void {
    this.vehicle.chassisNumber = this.form.controls['chassisNumber'].value!;
    this.vehicle.model = this.form.controls['model'].value!;
    this.vehicle.year = this.form.controls['year'].value!;
    this.vehicle.color = this.form.controls['color'].value!;
    this.vehicle.price = this.form.controls['price'].value!;
    this.vehicle.mileage = this.form.controls['mileage'].value!;
    this.vehicle.systemVersion = this.form.controls['systemVersion'].value!;
    this.vehicle.ownerCpfCnpj = this.form.controls['ownerCpfCnpj'].value!;
    this.vehicle.isActive = this.form.controls['isActive'].value!;

    this.editEvent.emit(this.vehicle);
  }

  getAll(): void {
    this.vehicleService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Vehicle>(result);
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  create(): void {
    const vehicle = {} as Vehicle;

    vehicle.chassisNumber = this.form.controls['chassisNumber'].value!;
    vehicle.model = this.form.controls['model'].value!;
    vehicle.year = this.form.controls['year'].value!;
    vehicle.color = this.form.controls['color'].value!;
    vehicle.price = this.form.controls['price'].value!;
    vehicle.mileage = this.form.controls['mileage'].value!;
    vehicle.systemVersion = this.form.controls['systemVersion'].value!;
    vehicle.ownerCpfCnpj = this.form.controls['ownerCpfCnpj'].value!;
    vehicle.isActive = this.form.controls['isActive'].value!;

    this.vehicleService.create(vehicle).subscribe((result) => {
      if (result) {
        this.clearForm();
        this.getAll();
      }
    });
  }

  update(vehicle: Vehicle): void {
    const dialogRef = this.dialog.open(EditDialogComponent, {
      width: '600px',
      data: { model: vehicle, dialogType: DialogType.EditVehicle }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.vehicleService.update(vehicle, vehicle.chassisNumber)
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

  delete(vehicle: Vehicle): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '600px',
      data: {
        type: 'vehicle',
        text: vehicle.chassisNumber,
        dialogType: DialogType.EditVehicle
      }
    });

    dialogRef.afterClosed()
      .pipe(
        switchMap((result) => {
          if (result) {
            return this.vehicleService.delete(vehicle.chassisNumber)
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
