import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
url:string = "http://localhost:59595/api/LoginUsers";
logouturl:string = "http://localhost:59595/api/LogOut";
ordHistory_url:string = "http://localhost:59595/api/Orders";
gifts_url:string = "http://localhost:59595/api/Gifts";
order_url:string = "http://localhost:59595/api/Orders";
ord_details_url:string = "http://localhost:59595/api/OrderDetails"
latestId_url:string = "http://localhost:59595/api/Orders/GetId/descending"

constructor(private _httpClient: HttpClient) { }

getLoggedUser(data: any): Observable<any>{
  // console.log(data)
  return this._httpClient.post(this.url, data,  { responseType: 'json' }).pipe(
    catchError(this.handleError)
  );
}


getUserById(id: any): Observable<any> {
  return this._httpClient.get(`${this.url}/${id}`).pipe(
    catchError(this.handleError)
  );
}

logOutUser(id: any): Observable<any>{
return this._httpClient.put(`${this.logouturl}/${id}`, {}).pipe(
  catchError(this.handleError)
);
}

getOrderHistory(id: any): Observable<any>{
  return this._httpClient.get(`${this.ordHistory_url}/${id}`).pipe(
    catchError(this.handleError)
  );
  }

  getAllGifts(): Observable<any>{
    return this._httpClient.get(this.gifts_url).pipe(
      catchError(this.handleError)
    );
  }

  postOrder(data: any): Observable<any>{
    console.log(data);
    return this._httpClient.post(this.order_url, data).pipe(
      catchError(this.handleError)
    );
  }

  postOrderDetails(data: any): Observable<any>{
    return this._httpClient.post(this.ord_details_url, data).pipe(
      catchError(this.handleError)
    );
  }

  getLatestUserId(): Observable<any>{
    return this._httpClient.get(this.latestId_url).pipe(
      catchError(this.handleError)
    );
  }

handleError(error: HttpErrorResponse) {
  if (error.error instanceof ErrorEvent) {
    console.error('An error occurred:', error.error.message);
  } else {
      alert(error.error.message);
  }
  return throwError(
    'Something bad happened; please try again later.');
};
}
