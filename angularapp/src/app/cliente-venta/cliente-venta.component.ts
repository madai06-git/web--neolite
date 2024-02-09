import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { VentasService } from './ventas.service';
@Component({
  selector: 'app-cliente-venta',
  //standalone: true,
  //imports: [],
  templateUrl: './cliente-venta.component.html',
  styleUrl: './cliente-venta.component.css'
})
export class ClienteVentaComponent {
  venta = {
    "ventaId": 0,
    "nombre": "",
    "categoria": "",
    "precio": 0,
    "anticipo": 0,
    "fechaentrada": "",
    "fechasalida": ""

  };
  //venta: any = {};

  constructor(private ventasService: VentasService) {}

  registrarVenta() {
    this.ventasService.registrarVenta(this.venta)
      .subscribe(
        (respuesta: any) => {
          alert('Venta dada de alta: ');
        },
        (error: any) => {   
           alert('Error al dar de alta la venta:' + error.message);
           console.error('Error al dar de alta la venta:', error);
        } 

     );
  }

}

