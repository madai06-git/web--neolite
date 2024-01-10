import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpcionesTrabajoComponent } from './opciones-trabajo.component';

describe('OpcionesTrabajoComponent', () => {
  let component: OpcionesTrabajoComponent;
  let fixture: ComponentFixture<OpcionesTrabajoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OpcionesTrabajoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OpcionesTrabajoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
