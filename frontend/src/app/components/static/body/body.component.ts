import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { SidenavService } from 'src/app/services/sidenav.service';
import { SpinnerService } from 'src/app/services/spinner.service';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.scss']
})
export class BodyComponent implements AfterViewInit {

  @ViewChild('sidenav') public sidenav: MatSidenav;

  constructor(
    private spinnerService: SpinnerService,
    private sidenavService: SidenavService
  ) { }

  ngAfterViewInit(): void {
    this.sidenavService.setSidenav(this.sidenav);
  }

  isVisible(): boolean {
    return this.spinnerService.isVisible();
  }

}
