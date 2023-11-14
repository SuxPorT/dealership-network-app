import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private firstVisit = true;

  isFirstVisit() {
    return this.firstVisit;
  }

  setVisited() {
    this.firstVisit = false;
  }

}
