import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Accessory } from 'src/app/models/accessory.model';
import { AccessoryService } from 'src/app/services/accessory.service';

@Component({
  selector: 'app-accessory',
  templateUrl: './accessory.component.html',
  styleUrls: ['./accessory.component.scss']
})
export class AccessoryComponent implements OnInit {
  dataSource!: MatTableDataSource<Accessory>;

  constructor(private accessoryService: AccessoryService) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    this.accessoryService.getAll().subscribe((result) => {
      if (result) {
        this.dataSource = new MatTableDataSource<Accessory>(result);

        console.log(this.dataSource);
      }
    });
  }

}
