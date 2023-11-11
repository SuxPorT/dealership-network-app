import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  private duration = 3000;

  constructor(private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.snackBar.open(`Welcome to Dealership Network App!`, 'Close',
      { duration: this.duration, panelClass: 'success-snackbar' });
  }

}
