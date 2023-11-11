import { Component } from '@angular/core';
import { SidenavService } from 'src/app/services/sidenav.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  constructor(private sidenavService: SidenavService) { }

  toggleSidenav(): void {
    this.sidenavService.toggle();
  }

}
