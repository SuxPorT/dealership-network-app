import { AfterViewInit, Component, QueryList, ViewChildren } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { SidenavService } from 'src/app/services/sidenav.service';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.scss']
})
export class BodyComponent implements AfterViewInit {

  @ViewChildren('sidenav') public sidenav: QueryList<MatSidenav>;

  constructor(private sidenavService: SidenavService) { }

  public ngAfterViewInit(): void {
    this.sidenavService.setSidenav(this.sidenav.first);
  }

}
