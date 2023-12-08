import { Component } from '@angular/core';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent {
  hospitalInfo = {
    nombre: 'Hospital del Calzado',
    mision: 'Somos un hospital especializado en el cuidado y reparación de calzado. Nuestra misión es proporcionar servicios de alta calidad para garantizar la comodidad y durabilidad de su calzado,Nuestros servicios de reparación se realizan con equipos altamente especializados para la fabricación y restauración de calzado, contamos con herramientas profesionales que garantizan mantener los acabados de costura y curtiduría de fabrica..'
  };
  public mostrarMensaje = true;

  cerrarMensaje() {
    this.mostrarMensaje = false;

  }
}

