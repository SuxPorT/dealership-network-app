import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Phone } from 'src/app/models/phone.model';
import { PhoneService } from 'src/app/services/phone.service';

@Component({
  selector: 'app-phone',
  templateUrl: './phone.component.html',
  styleUrls: ['./phone.component.scss']
})
export class PhoneComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns = ["id", "number", "ownerCpfCnpj", "actions"];
  dataSource!: MatTableDataSource<Phone>;

  constructor(private phoneService: PhoneService) { }

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
    this.phoneService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Phone>(result);
        this.dataSource.paginator = this.paginator;

        console.log(this.dataSource);
      }
    });
  }

}
