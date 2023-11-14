import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AccessoryService } from 'src/app/services/accessory.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  private duration = 3000;

  constructor(
    private loginService: LoginService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    if (this.loginService.isFirstVisit()) {
      this.snackBar.open(`Welcome to Dealership Network App!`, 'Close',
        { duration: this.duration, panelClass: 'success-snackbar' });

      this.loginService.setVisited();
    }

  }

}
