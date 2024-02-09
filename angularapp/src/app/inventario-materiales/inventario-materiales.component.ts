import { Component } from '@angular/core';
import { InventarioService } from 'src/app/inventario-materiales/inventario.service'

@Component({
  selector: 'app-inventario-materiales',
  templateUrl: './inventario-materiales.component.html',
  styleUrl: './inventario-materiales.component.css'
})
export class InventarioMaterialesComponent {
  materiales: any[] = [];

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

  consultarMateriales() {
    this.inventarioService.consultarMateriales().subscribe(
      (respuesta: any[]) => {
        this.materiales = respuesta.map(material => ({
          materialId: material.materialId,
          nombreMaterial: material.nombreMaterial,
          cantidadStock: material.cantidadStock,
          precio: material.precio

        })); // Asigna los materiales devueltos por el servicio a la propiedad materiales
      },
      (error) => {
        console.error('Error al consultar materiales:', error);
      }
    );
  }


}
