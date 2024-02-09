import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InventarioService {
  private apiUrl = 'https://localhost:7216/api/InventarioMateriales';



  constructor(private http: HttpClient) { }
  registrarmaterial(inventario: any): Observable<any> {
    return this.http.post(this.apiUrl, inventario);
  }
}
