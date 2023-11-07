import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Accessory } from 'src/app/models/accessory.model';
import { AccessoryService } from 'src/app/services/accessory.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DialogComponent } from '../../shared/dialog/dialog.component';
import { DialogType } from 'src/app/models/enums/dialog-type';

@Component({
  selector: 'app-accessory',
  templateUrl: './accessory.component.html',
  styleUrls: ['./accessory.component.scss']
})
export class AccessoryComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  @Input() selectedAccessory: Accessory;
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
    if (!this.isEditMode) {
      if (this.form.valid) {
        this.create();
      }
    } else {
      this.emitEditEvent();
    }
  }

  fillForm(): void {
    this.form.controls['description'].setValue(this.selectedAccessory.description);
    this.form.controls['isActive'].setValue(this.selectedAccessory.isActive);
  }

  clearForm(): void {
    this.form.controls['description'].setValue('');
    this.form.controls['isActive'].setValue(false);
  }

  emitEditEvent(): void {
    this.selectedAccessory.description = this.form.controls['description'].value!;
    this.selectedAccessory.isActive = this.form.controls['isActive'].value!;

    this.editEvent.emit(this.selectedAccessory);
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
    console.log(this.form.value);
  }

  update(accessory: Accessory): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '600px',
      data: { entity: accessory, dialogType: DialogType.EditAccessory }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        console.log(result);
      }
    });
  }

  delete(accessory: Accessory): void {
    console.log(accessory);
  }

}
