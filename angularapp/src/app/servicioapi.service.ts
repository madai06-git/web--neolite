import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrdenTrabajo } from './reparaciones/orden-trabajo.model'
import { DetalleReparacion } from './reparaciones/detalle-reparacion.model'
import { FacturaPago } from './reparaciones/factura-pago.model'


@Injectable({
  providedIn: 'root'
})

export class ServicioDeApi {
  private apiUrl = 'tu-url-api'; // Reemplaza con la URL real de tu API

  constructor(private http: HttpClient) { }

  darDeAltaVenta(venta: any): Observable<any> {
    return this.http.post(`${this.apiUrl}`, venta);
  }

  guardarInformacion(ordenTrabajo: OrdenTrabajo, detalleReparacion: DetalleReparacion, facturaPago: FacturaPago): void {
    // Aquí haz la llamada a tu API para guardar la información
    const url = `${this.apiUrl}/guardarInformacion`;
    //return of('Información guardada exitosamente');
  }
}
