import { Component, Injector, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { AppComponentBase } from '@shared/app-component-base';
import {
  FieldCreateDto,
  FieldEditDto,
  FieldListDto,
  FieldServiceProxy,
} from '@shared/service-proxies/service-proxies';
import {
  FieldEditModalComponent,
  IFieldEmit,
} from 'configurations/ui/fields-edit-modal/fields-edit-modal.component';
import { NzModalService } from 'ng-zorro-antd/modal';
import {
  BehaviorSubject,
  Observable,
  Subscription,
  debounceTime,
  distinctUntilChanged,
  finalize,
  switchMap,
} from 'rxjs';

@Component({
  templateUrl: './configurations-fields.page.html',
})
export class ConfigurationsFieldsPage
  extends AppComponentBase
  implements OnDestroy
{
  searchInput = new FormControl('');
  typeInput = new FormControl();
  fieldService$: Observable<FieldListDto[]>;
  saving = false;
  selectedTypeFilter: number;

  private subs = new Subscription();
  private reload$ = new BehaviorSubject<boolean>(true);

  constructor(
    injector: Injector,
    private _fieldService: FieldServiceProxy,
    private _nzModalService: NzModalService
  ) {
    super(injector);
    this.subs.add(
      this.searchInput.valueChanges
        .pipe(distinctUntilChanged(), debounceTime(300))
        .subscribe(() => {
          this.reload$.next(true);
        })
    );

    this.typeInput.setValue('');
    this.typeInput.valueChanges.subscribe();

    this.fieldService$ = this.reload$.pipe(
      switchMap(() =>
        this._fieldService.getAll(
          this.searchInput.value
        )
      )
    );
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  add() {
    const modal = this._nzModalService.create({
      nzTitle: this.l('Create'),
      nzContent: FieldEditModalComponent,
      nzFooter: null,
    });

    modal.componentInstance.onSave.subscribe((value) => {
      const createDto = new FieldCreateDto({
        ...value,
      });

      this._fieldService
        .create(createDto)
        .pipe(finalize(() => (modal.componentInstance.saving = false)))
        .subscribe(() => {
          modal.close();
          this.reload$.next(true);
          this.notify.success(this.l('SavedSuccessfully'));
        });
    });
  }

  edit(service: FieldEditDto) {
    this._fieldService
      .get(service.id)
      .subscribe(
        ({ id, name, status }) => {
          const modal = this._nzModalService.create({
            nzTitle: this.l('Edit'),
            nzContent: FieldEditModalComponent,
            nzFooter: null,
          });

          modal.componentInstance.initForm(
            id,
            name,
            status
          );

          modal.componentInstance.onSave.subscribe((data: IFieldEmit) => {
            const editDto = new FieldEditDto({
              ...data,
            });

            this._fieldService
              .edit(editDto)
              .pipe(finalize(() => (this.saving = false)))
              .subscribe(() => {
                modal.close();
                this.reload$.next(true);
                this.notify.success(this.l('SavedSuccessfully'));
              });
          });
        }
      );
  }

  delete(service: FieldEditDto) {
    this.message.confirm(
      `${service.name}` + ' ' + this.l('WillBeDeleted'),
      this.l('AreYouSure'),
      (isConfirmed) => {
        if (isConfirmed) {
          this._fieldService.delete(service.id).subscribe(() => {
            this.reload$.next(true);
            this.notify.success(this.l('DeletedSuccessfully'));
          });
        }
      }
    );
  }

  onFilterSelectValueChange(value: number) {
    if (value === 0) {
      this.selectedTypeFilter = value;
    } else if (value === 1) {
      this.selectedTypeFilter = value;
    } else {
      this.selectedTypeFilter = undefined;
    }
    this.reload$.next(true);
  }
}
