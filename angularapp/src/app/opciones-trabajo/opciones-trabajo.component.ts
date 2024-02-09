import { Component ,Input} from '@angular/core';

import { TrabajosService } from 'src/app/services/trabajos.service';

@Component({
  selector: 'app-opciones-trabajo',
  standalone: true,
  imports: [],
  templateUrl: './opciones-trabajo.component.html',
  styleUrl: './opciones-trabajo.component.css'
})
export class OpcionesTrabajoComponent {
  @Input() empleadoId!: number;
  constructor(private trabajoService: TrabajosService) { }

  solicitarDatos(tipoRestauracion: string): void {
    const numeroNota = window.prompt(`Ingrese el número de nota para ${tipoRestauracion}:`);
    const fecha = window.prompt(`Ingrese la fecha para ${tipoRestauracion} (Formato: DD/MM/AAAA):`);

    if (numeroNota && fecha) {
      this.trabajoService.registrarTrabajo(this.empleadoId, tipoRestauracion, numeroNota, fecha).subscribe(
        response => {
          console.log('Trabajo registrado exitosamente.', response);
        },
        error => {
          console.error('Error al registrar el trabajo:', error);
        }
      );

      // Realiza acciones con la información ingresada
      console.log(`${tipoRestauracion} - Número de Nota: ${numeroNota}, Fecha: ${fecha}`);
    }
  }

}
