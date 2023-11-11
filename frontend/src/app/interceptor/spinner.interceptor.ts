import { Inject, Injectable, InjectionToken } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse
} from '@angular/common/http';
import { Observable, tap, timeout } from 'rxjs';
import { SpinnerService } from '../services/spinner.service';

export const DEFAULT_TIMEOUT = new InjectionToken<number>('defaultTimeout');

@Injectable()
export class SpinnerInterceptor implements HttpInterceptor {

  private count: number = 0;

  constructor(
    @Inject(DEFAULT_TIMEOUT)
    protected defaultTimeout: number,
    private spinnerService: SpinnerService
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler):
    Observable<HttpEvent<any>> {
    this.spinnerService.show();

    const timeoutValue = req.headers.get('timeout') || this.defaultTimeout;
    const timeoutValueNumeric = Number(timeoutValue);

    return next.handle(req).pipe(
      tap({
        next: (event: HttpEvent<any>) => {
          if (event instanceof HttpResponse) {
            timeout(timeoutValueNumeric);
            this.spinnerService.hide();
          }
        },
        error: (_error) => {
          this.count--;

          if (this.count <= 0) {
            timeout(timeoutValueNumeric);
            this.spinnerService.hide();
          }
        }
      }),
    );
  }

}
