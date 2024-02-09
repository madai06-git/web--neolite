import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {
  private apiUrl = 'https://localhost:7216/api/Empleadoes'; // Reemplaza con la URL de tu backend

  constructor(private http: HttpClient) { }

  darDeAltaEmpleado(empleado: any): Observable<any> {
    return this.http.post(`${this.apiUrl}`, empleado);
  }
}



