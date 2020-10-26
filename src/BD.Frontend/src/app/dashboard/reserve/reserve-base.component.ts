import { ElementRef } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormBaseComponent } from 'src/app/core/base-components/form-base.component';
import { Reserve } from 'src/app/core/models/reserve';

export abstract class ReserveBaseComponent extends FormBaseComponent {
    reserve: Reserve;
    errors: any[] = [];
    reserveForm: FormGroup;

    constructor() {
        super();

        this.validationMessages = {
            dateStart: {
                required: 'Informe a data de Entrada',
                date: 'Informe um data válida',
                minDate: 'A reserve deve ter ao menos 3 dias de antecedência'
            },
            dateEnd: {
                required: 'Informe a data de Saida',
                date: 'Informe um data válida',
                minDate: 'A data de fim não pode ser menor que a de Entrada'
            },
            price: {
                required: 'Informe o preço da Reserva',
                min: 'Valor mínimo de 1',         
            },
            entry: {
                required: 'Informe o valor da Entrada',
                min: 'Valor mínimo de 1',         
            },
            description: {
                required: 'Informe uma descrição',
                minlength: 'Mínimos de 10 caracretes',
                maxlength: 'Máximo de 500 caracteres'
            },
        };

        super.configurarMensagensValidacaoBase(this.validationMessages);
    }

    protected configurarValidacaoFormulario(formInputElements: ElementRef[]) {
        super.configurarValidacaoFormularioBase(formInputElements, this.reserveForm);
    }
}