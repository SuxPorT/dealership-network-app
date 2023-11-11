import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
} from '@angular/common/http';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class SnackbarInterceptor implements HttpInterceptor {

  private duration = 500000;

  constructor(private snackBar: MatSnackBar) { }

  intercept(request: HttpRequest<any>, next: HttpHandler):
    Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      tap(e => {
        switch (request.method) {
          case "POST":
            if (e instanceof HttpResponse && e.status == 200)
              this.snackBar.open('Record created successfully!', 'Close',
                { duration: this.duration, panelClass: 'success-snackbar' });
            break;
          case "PUT":
            if (e instanceof HttpResponse && e.status == 200)
              this.snackBar.open('Record updated successfully!', 'Close',
                { duration: this.duration, panelClass: 'success-snackbar' });
            break;
          case "DELETE":
            if (e instanceof HttpResponse && e.status == 200)
              this.snackBar.open('Record deleted succesfully!', 'Close',
                { duration: this.duration, panelClass: 'success-snackbar' });
            break;
        }
      }),
      catchError(error => {
        this.snackBar.open('Error while saving.', 'Close',
          { duration: this.duration, panelClass: 'error-snackbar' });
        return throwError(() => new Error(error));
      })
    );
  }

}
