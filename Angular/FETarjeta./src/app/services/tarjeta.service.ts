import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TarjetaService {

  private myAppUrl = 'https://localhost:44389/';
  private myApiUrl = 'api/CuentaCliente/';
  private myApiUrlClient = 'api/Client/';
  private myApiUrlCuenta = 'api/Cuenta/';

  constructor(private http: HttpClient) { }

  getListTarjetas(): Observable<any>{
    return this.http.get(this.myAppUrl + this.myApiUrl);
  }

  deleteTarjeta(id: number): Observable<any>{
    return this.http.delete(this.myAppUrl + this.myApiUrl + id);
  }

  saveTarjeta(tarjeta: any): Observable<any>{
    return this.http.post(this.myAppUrl + this.myApiUrl, tarjeta);
  }

  updateDineroCuentaCliente(id: number, tarjeta: any, operacion: any): Observable<any>{
    return this.http.put(this.myAppUrl + this.myApiUrl + id + "," + operacion, tarjeta);
  }

  saveClient(Client: any): Observable<any>{
    return this.http.post(this.myAppUrl + this.myApiUrlClient, Client);
  }

  saveCuenta(Cuenta: any): Observable<any>{
    return this.http.post(this.myAppUrl + this.myApiUrlCuenta, Cuenta);
  }

  saveCuentaCliente(CuentaCliente: any): Observable<any>{
    return this.http.post(this.myAppUrl + this.myApiUrl, CuentaCliente);
  }

  getCuentaClienteid(id: number, password: any): Observable<any>{
    return this.http.get(this.myAppUrl + this.myApiUrl +id + "," + password );
  }
}
