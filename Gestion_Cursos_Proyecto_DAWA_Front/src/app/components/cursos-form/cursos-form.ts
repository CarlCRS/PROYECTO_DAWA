import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

interface Curso {
  id: number;
  nombre: string;
  docente: string;
  activo: boolean;
}

@Component({
  imports: [FormsModule],
  selector: 'app-cursos-form',
  standalone: true,
  styleUrl: './cursos-form.css',
  templateUrl: './cursos-form.html',
})
export class CursosForm {
  @Output() cursoAgregado = new EventEmitter<Curso>();
  nombre: string = '';
  docente: string = '';
  estado: boolean = true;

  agregarNuevoCurso() {
    if (this.nombre.trim() === '' || this.docente.trim() === '') {
      alert('Por favor, complete todos los campos antes de agregar un curso.');
      return;
    }

    const nuevoCurso: Curso = {
      id: Date.now(),
      nombre: this.nombre,
      docente: this.docente,
      activo: this.estado,
    };

    this.cursoAgregado.emit(nuevoCurso);
    this.nombre = '';
    this.docente = '';
    this.estado = true;
    console.log('Nuevo curso agregado:', nuevoCurso);
  }
}
