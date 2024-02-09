import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InventarioMaterialesComponent } from 'src/app/inventario-materiales/inventario-materiales.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Importa FormsModule y ReactiveFormsModule


@NgModule({
  declarations: [

    InventarioMaterialesComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    InventarioMaterialesComponent,
  ]

})
export class InventarioMaterialesModule { }
