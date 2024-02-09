import { Component } from '@angular/core';
//import { TuServicioDeApi } from '../servicioapi.service';
import { ServicioDeApi } from 'src/app/servicioapi.service';
import { VentasService } from './ventas.service';
@Component({
  selector: 'app-cliente-venta',
  standalone: true,
  imports: [],
  templateUrl: './cliente-venta.component.html',
  styleUrl: './cliente-venta.component.css'
})
export class ClienteVentaComponent {
  /*venta: any = {};

  constructor(private ventasService: VentasService) {}

  registrarVenta() {
    this.ventasService.registrarVenta(this.venta).subscribe(response => {
      console.log('Venta registrada:', response);
      // Aquí puedes agregar lógica adicional, como limpiar el formulario o mostrar un mensaje de éxito
    }, error => {
      console.error('Error al registrar la venta:', error);
      // Aquí puedes manejar errores, como mostrar un mensaje de error al usuario
    });
  }
  /*venta = {

    "ventaId": 0,
    "nombre": "",
    "categoria": "",
    "precio": "",
    "anticipo": "",
    "fechaentrada": "",
    "fechasalida": ""
  };

  constructor(private servicioDeApi: ServicioDeApi) { }

  darDeAltaVenta() {
    this.servicioDeApi.darDeAltaVenta(this.venta)
      .subscribe(
        (respuesta: any) => {
          alert('Venta dada de alta: ');
        },
        (error: any) => {
          alert('Error al dar de alta la venta:' + error.message);
          console.error('Error al dar de alta la venta:', error);
        }
      );

  }*/
}

