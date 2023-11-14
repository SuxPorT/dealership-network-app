import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
} from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class SnackbarInterceptor implements HttpInterceptor {

  private duration = 3000;

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
      catchError((errorResponse) => {
        const error = errorResponse.error;
        let errorSnackbarMessage = 'An error occurred while saving.';

        if (error?.errors) {
          for (const key in error.errors) {
            if (error.errors.hasOwnProperty(key)) {
              errorSnackbarMessage += `\n${key}: ${error.errors[key][0]}`;
            }
          }
        } else {
          if (error instanceof ProgressEvent) {
            errorSnackbarMessage += "\nBackend is currently unavailable.";
          } else {
            errorSnackbarMessage += `\n${error}`;
          }
        }

        this.snackBar.open(errorSnackbarMessage, 'Close',
          { duration: this.duration, panelClass: 'error-snackbar' });

        const statusCode = error?.status || errorResponse.status;
        const errorMessage = error?.title || error.type || error;
        const traceId = ` (Trace ID: ${error?.traceId}`;
        const formattedError = `HTTP Error ${statusCode}: ${errorMessage}${traceId}`;

        throw new Error(formattedError);
      })
    );
  }

}
