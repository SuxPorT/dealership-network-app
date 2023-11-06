import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Vehicle } from 'src/app/models/vehicle.model';
import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.scss']
})
export class VehicleComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns = [
    "id", "chassisNumber", "model", "year", "color",
    "price", "mileage", "systemVersion", "ownerCpfCnpj", "actions"
  ];
  dataSource!: MatTableDataSource<Vehicle>;

  constructor(private vehicleService: VehicleService) { }

  ngOnInit(): void {
    this.getAll();
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

  getAll(): void {
    this.vehicleService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Vehicle>(result);
        this.dataSource.paginator = this.paginator;

        console.log(this.dataSource);
      }
    });
  }

}
