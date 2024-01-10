import { Component } from '@angular/core';

@Component({
  selector: 'app-opciones-trabajo',
  standalone: true,
  imports: [],
  templateUrl: './opciones-trabajo.component.html',
  styleUrl: './opciones-trabajo.component.css'
})
export class OpcionesTrabajoComponent {

  mostrarRestauracionCalzado() {
    // Lógica para mostrar la sección de restauración de calzado
    console.log('Mostrar Restauración de Calzado');
  }

  mostrarRestauracionAccesorios() {
    // Lógica para mostrar la sección de restauración de accesorios
    console.log('Mostrar Restauración de Accesorios');
  }

  mostrarPintadosGenerales() {
    // Lógica para mostrar la sección de pintados generales
    console.log('Mostrar Pintados Generales');
  }


 /* mostrarCalzado: boolean = false;
  mostrarAccesorios: boolean = false;
  mostrarPintados: boolean = false;
  mostrarFormulario(opcion: string) {
    this.mostrarCalzado = opcion === 'calzado';
    this.mostrarAccesorios = opcion === 'accesorios';
    this.mostrarPintados = opcion === 'pintados';
  }



 mostrarFormulario = false;
  numeroNota: string | undefined;
  fecha: string | undefined

  mostrarCalzado() {
    this.mostrarFormulario = true;
  }

  mostrarAccesorios() {
    this.mostrarFormulario = true;
  }

  mostrarPintados() {
    this.mostrarFormulario = true;
  }

  realizarAccion() {
    console.log('Número de Nota:', this.numeroNota);
    console.log('Fecha:', this.fecha);

    this.numeroNota = '';
    this.fecha = '';
    this.mostrarFormulario = false;
  }

  onNumeroNotaChange(value: string): void {
    this.numeroNota = value;
  }

  onFechaChange(value: string): void {
    this.fecha = value;
  }*/

}
