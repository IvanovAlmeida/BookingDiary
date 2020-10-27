import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { fromEvent, merge, Observable } from 'rxjs';
import { Auth } from '../core/models/auth';
import { AuthService } from '../core/services/auth.service';
import { DisplayMessage, GenericValidator, ValidationMessages } from '../core/utils/generic-form-validation';
import { LocalStorageUtils } from '../core/utils/localstorage';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  returnUrl: string;

  formRecoveryPassword : boolean = false;
  authLogin: Auth;
  authRecovery: Auth;

  errorsLogin: any[] = [];
  errosRecovery: any[] = [];

  loginForm: FormGroup;
  recoveryForm: FormGroup;

  displayMessageLogin: DisplayMessage = {};
  displayMessageRecovery: DisplayMessage = {};
  genericValidatorLogin: GenericValidator;
  genericValidatorRecovery: GenericValidator;
  validationMessagesLogin: ValidationMessages;
  validationMessagesRecovery: ValidationMessages;

  localStorageUtil: LocalStorageUtils = new LocalStorageUtils();

  constructor(private elementRef: ElementRef, 
              private authService: AuthService, 
              private fb: FormBuilder, 
              private spinner: NgxSpinnerService, 
              private toastr: ToastrService,
              private router: Router,
              private route: ActivatedRoute) 
  {  

    this.configureValidationMessages();

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'];
  }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [ Validators.required, Validators.email ]],
      password: ['', [ Validators.required, Validators.minLength(6) ]]
    });
    this.recoveryForm = this.fb.group({
      emailRecovery: ['', [ Validators.required, Validators.email ]]
    });
  }

  ngAfterViewInit() {
    this.configureValidationForms(this.formInputElements);
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = '#1B4332';
  }

  flip() {
    this.formRecoveryPassword = !this.formRecoveryPassword;
  }

  login() : void {
    if(this.loginForm.dirty && this.loginForm.valid) {
      this.authLogin = Object.assign({}, this.authLogin, this.loginForm.value);

      this.spinner.show();
      this.authService.login(this.authLogin).subscribe(
        success => { this.proccessSuccessLogin(success); },
        fail => { this.proccessErrorLogin(fail); }
      );
    }
  }

  proccessSuccessLogin(response: any) {
    this.loginForm.reset();
    this.errorsLogin = [];

    this.spinner.hide();

    this.localStorageUtil.salvarDadosLocaisUsuario(response);

    let toast = this.toastr.success('Login realizado com sucesso!', 'Sucesso!', { timeOut: 1500 });
    if(toast) {
      toast.onHidden.subscribe(() => {
        this.returnUrl && this.returnUrl.length > 1
        ? this.router.navigate([this.returnUrl])
        : this.router.navigate(['/dashboard']);
      });
    }
  }

  proccessErrorLogin(fail: any) {
    this.spinner.hide();
    this.errorsLogin = fail.error.errors;
    //this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }

  protected configureValidationMessages() {
    this.validationMessagesLogin = {
      email: {
        required: 'Informe o e-mail',
        email: 'Informe um e-mail válido'
      },
      password: {
        required: 'Informe a senha',
        minlength: 'A senha deve ter no mínimo 6 caracteres'
      }
    };
    this.validationMessagesRecovery = {
      email: {
        required: 'Informe o e-mail',
        email: 'Informe um e-mail válido'
      },
    };

    this.configureMessagesValidationLogin(this.validationMessagesLogin);
    this.configureMessagesValidationRecovery(this.validationMessagesRecovery);
  }

  protected configureValidationForms(formInputElements: ElementRef[]) {
    let controlBlurs: Observable<any>[] = formInputElements
        .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(() => {
        this.validateForms(this.loginForm, this.recoveryForm);
    });
  }

  protected validateForms(validateFormLogin: FormGroup, validateFormRecovery: FormGroup) {
    this.displayMessageLogin = this.genericValidatorLogin.processarMensagens(validateFormLogin);
    this.displayMessageRecovery = this.genericValidatorRecovery.processarMensagens(validateFormRecovery);
  }

  protected configureMessagesValidationLogin(validationMessages: ValidationMessages) {
    this.genericValidatorLogin = new GenericValidator(validationMessages);
  }

  protected configureMessagesValidationRecovery(validationMessages: ValidationMessages) {
    this.genericValidatorRecovery = new GenericValidator(validationMessages);
  }
}