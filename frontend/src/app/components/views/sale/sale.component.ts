import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Sale } from 'src/app/models/sale.model';
import { SaleService } from 'src/app/services/sale.service';

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.scss']
})
export class SaleComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns = [
    "id", "price", "vehicleChassisNumber",
    "sellerId", "actions"
  ];
  dataSource!: MatTableDataSource<Sale>;

  constructor(private saleService: SaleService) { }

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
    this.saleService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Sale>(result);
        this.dataSource.paginator = this.paginator;
      }
    });
  }

}
