import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class VentasService {
  private apiUrl = 'https://localhost:7216/api/VentaClientes';

  constructor(private http: HttpClient) { }
  registrarVenta(venta: any): Observable<any> {
    return this.http.post(this.apiUrl, venta);
  }
}
