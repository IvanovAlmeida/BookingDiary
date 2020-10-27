import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { QueryStringUtils } from 'src/app/core/utils/query-string-utils';
import { User } from 'src/app/core/models/user';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BaseComponent } from 'src/app/core/base-components/base.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangePasswordComponent } from '../change-password/change-password.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './list.component.html',
})
export class ListComponent extends BaseComponent implements OnInit {

  public showSearchForm: boolean = false;
  public searchForm: FormGroup;
  public users: User[] = [];
  private user: User;

  private queryString = new QueryStringUtils();

  constructor(private router: Router,
    private userService: UserService,
    private fb: FormBuilder,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private modalService: NgbModal) {
    super();
  }

  ngOnInit(): void {
    let url: any = this.queryString.parseUrl(this.router.url);

    this.searchForm = this.fb.group({
      name: [url.query.name ?? ''],
      username: [url.query.username ?? ''],
      email: [url.query.email ?? ''],
      enabled: [url.query.enabled ?? 'true']
    });

    this.search();
  }

  toggleFormSearch() {
    this.showSearchForm = !this.showSearchForm;
  }

  search() {
    this.spinner.show();
    this.user = Object.assign({}, this.user, this.searchForm.value);

    this.userService.searchUsers(this.user).subscribe(
      r => {
        this.users = r;
        this.spinner.hide();
      },
      err => {
        console.log(err);
        this.spinner.hide();
      }
    );
  }

  async disableUser(id: number) {
    let confirm = await this.showConfirmBox('Atenção', 'Realmente deseja desativar este Usuário?');

    if(!confirm.isConfirmed) return;

    this.spinner.show();
    this.userService.disableUser(id).subscribe(
      success => {
        this.search();
        this.toastr.success('Usuário desativado com sucesso!', 'Sucesso');
      },
      error => {
        this.toastr.error('Ocorreu um erro ao desativar o Usuário!', 'Ops! :(');
        this.spinner.hide();
      }
    );
  }

  async enableUser(id: number) {
    let confirm = await this.showConfirmBox('Atenção', 'Realmente deseja reativar este Usuário?');

    if(!confirm.isConfirmed) return;

    this.spinner.show();
    this.userService.enableUser(id).subscribe(
      success => {
        this.search();
        this.toastr.success('Usuário reativado com sucesso!', 'Sucesso');
      },
      error => {
        this.toastr.error('Ocorreu um erro ao reativar o Usuário!', 'Ops! :(');
        this.spinner.hide();
      }
    );
  }

  openModalPassword(user: User) {
    const modalRef = this.modalService.open(ChangePasswordComponent, { centered: true });
    modalRef.componentInstance.user = user;
  }
}
