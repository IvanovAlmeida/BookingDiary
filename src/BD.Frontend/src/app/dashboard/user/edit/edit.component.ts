import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { FormBaseComponent } from 'src/app/core/base-components/form-base.component';
import { Role } from 'src/app/core/models/role';
import { User } from 'src/app/core/models/user';
import { RoleService } from 'src/app/core/services/role.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './edit.component.html',
})
export class EditComponent extends FormBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  errorsGroups: any[] = [];
  editForm: FormGroup;
  public user: User;
  public role: Role;

  groups$: Observable<any[]>;
  roles: Role[] = [];
  selectedRoles: any[] = [];
  editFormGroups: FormGroup;

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private roleService: RoleService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) {
    super();
    this.user = this.route.snapshot.data['user'];

    this.validationMessages = {
      name: {
        required: 'Informe o nome',
      },
      email: {
        required: 'Informe o e-mail',
        email: 'Email inválido'
      }
    };
    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  ngOnInit(): void {
    this.editForm = this.fb.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]]
    });

    this.editForm.patchValue({
      name: this.user.name,
      email: this.user.email
    });

    this.editFormGroups = this.fb.group({
      groups: ['']
    });


    this.groups$ = this.roleService.searchRoles(this.role);
    this.selectedRoles = this.user.roles;

    this.spinner.hide();
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.editForm);
  }

  editUser() { }

  updateGroups() {
    this.userService.updateRoles(this.user.id, this.selectedRoles).subscribe(
      r => {
        let toast = this.toastr.success('Grupos atualizados com sucesso!', 'Sucesso!', { timeOut: 1000 });
      },
      err => {
        let toast = this.toastr.error('Ocorreu um erro ao atualizar os grupos!', 'Ops!', { timeOut: 1000 });
      }
    );
  }
}
