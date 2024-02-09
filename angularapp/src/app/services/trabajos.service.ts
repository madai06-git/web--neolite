import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'
import { Observable, throwError } from 'rxjs';
/*import { catchError } from 'rxjs/operators';
import { pipe } from 'rxjs';
//import { Trabajo } from './trabajo.model';*/

@Injectable({
  providedIn: 'root'
})
export class TrabajosService {
  private apiUrl = 'https://localhost:7216/api/TrabajosRealizados';

  constructor(private http: HttpClient) { }

  registrarTrabajo(empleadoid: number, tipoRestauracion: string, numeroNota: string, fecha: string): Observable<any> {

    const trabajoData = {
     empleadoid,tipoRestauracion,numeroNota, fecha

    };
    return this.http.post<any>(this.apiUrl, trabajoData)

  }

  obtenerTrabajosRealizados(empleadoId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}?empleadoId=${empleadoId}`);
  }
}
