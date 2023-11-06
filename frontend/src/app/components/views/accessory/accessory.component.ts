import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Accessory } from 'src/app/models/accessory.model';
import { AccessoryService } from 'src/app/services/accessory.service';

@Component({
  selector: 'app-accessory',
  templateUrl: './accessory.component.html',
  styleUrls: ['./accessory.component.scss']
})
export class AccessoryComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns = ["id", "description", "actions"];
  dataSource!: MatTableDataSource<Accessory>;

  constructor(private accessoryService: AccessoryService) { }

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
    this.accessoryService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Accessory>(result);
        this.dataSource.paginator = this.paginator;

        console.log(this.dataSource);
      }
    });
  }

}
