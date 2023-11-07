import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Seller } from 'src/app/models/seller.model';
import { SellerService } from 'src/app/services/seller.service';

@Component({
  selector: 'app-seller',
  templateUrl: './seller.component.html',
  styleUrls: ['./seller.component.scss']
})
export class SellerComponent implements OnInit {

  @ViewChild('sort') sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns = ["id", "name", "baseSalary", "actions"];
  dataSource!: MatTableDataSource<Seller>;

  constructor(private sellerService: SellerService) { }

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
    this.sellerService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Seller>(result);
        this.dataSource.paginator = this.paginator;
      }
    });
  }

}
