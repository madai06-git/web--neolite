import { Component } from '@angular/core';
import { OrdenTrabajo } from './orden-trabajo.model'
import { DetalleReparacion } from './detalle-reparacion.model'
import { FacturaPago } from './factura-pago.model'
import { ServicioDeApi } from 'src/app/servicioapi.service';


@Component({
  selector: 'app-reparaciones',
  standalone: true,
  imports: [],
  templateUrl: './reparaciones.component.html',
  styleUrl: './reparaciones.component.css'
})
export class ReparacionesComponent {
  ordenTrabajo: OrdenTrabajo = new OrdenTrabajo(new Date(), new Date(), '', 0);
  detalleReparacion: DetalleReparacion = new DetalleReparacion('', '', 0, 0);
  facturaPago: FacturaPago = new FacturaPago(new Date(), 0, 0);

  constructor(private tuServicioDeApi: ServicioDeApi) { }

  guardarInformacion() {
    // Aquí puedes llamar a tu servicio para enviar la información al backend
    this.tuServicioDeApi.guardarInformacion(this.ordenTrabajo, this.detalleReparacion, this.facturaPago);
  }


  // reparaciones() {

  //}
}
// orden-trabajo.model.ts
