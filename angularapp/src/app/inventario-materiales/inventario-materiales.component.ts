import { Component } from '@angular/core';
import { InventarioService } from 'src/app/inventario-materiales/inventario.service'

@Component({
  selector: 'app-inventario-materiales',
  templateUrl: './inventario-materiales.component.html',
  styleUrl: './inventario-materiales.component.css'
})
export class InventarioMaterialesComponent {
  inventario = {
    "materialId": 0,
    "nombrematerial": "",
    "cantidadstock": 0,
    "precio": 0,
  };
  constructor(private inventarioService: InventarioService) { }

  registrarmaterial() {
    this.inventarioService.registrarmaterial(this.inventario)
      .subscribe(
        (respuesta: any) => {
          alert('Material dado de alta: ');
        },
        (error: any) => {
          alert('Error al dar de alta el material:' + error.message);
          console.error('Error al dar de alta el material:', error);
        }

      );
  }


}
