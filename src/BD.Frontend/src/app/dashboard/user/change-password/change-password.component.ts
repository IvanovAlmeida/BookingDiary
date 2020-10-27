import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { FormBaseComponent } from 'src/app/core/base-components/form-base.component';
import { User } from 'src/app/core/models/user';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html'
})
export class ChangePasswordComponent extends FormBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  @Input() user: User;

  public passwordForm: FormGroup;
  errors: any[] = [];

  constructor(public activeModal: NgbActiveModal,
              private userService: UserService,
              private fb: FormBuilder,
              private spinner: NgxSpinnerService,
              private toastr: ToastrService) {
    super();

    this.validationMessages = {
      password: {
        required: 'Informe a senha',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
      }
    };
    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  changePassword() {
    if (this.passwordForm.dirty && this.passwordForm.valid) {
      this.user = Object.assign({}, this.user, this.passwordForm.value);
      this.spinner.show();
      this.userService.changeUserPassword(this.user.id, this.user.password).subscribe(
        s => {
          this.spinner.hide();
          let toast = this.toastr.success('Senha alterada com sucesso!', 'Sucesso!', { timeOut: 1500 });
          this.activeModal.dismiss();
        },
        e => {
          this.spinner.hide();
          this.errors = e.error.errors;
          let toast = this.toastr.error('Erro ao alterar a senha!', 'Sucesso!', { timeOut: 1500 });
        }
      );
    }
  }

  ngOnInit(): void {
    this.passwordForm = this.fb.group({
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.passwordForm);
  }

}
