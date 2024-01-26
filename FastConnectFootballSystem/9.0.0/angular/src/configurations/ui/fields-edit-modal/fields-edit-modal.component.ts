import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  FieldEditDto,
} from '@shared/service-proxies/service-proxies';
import { NzModalRef } from 'ng-zorro-antd/modal';
import { BehaviorSubject, Observable, tap } from 'rxjs';

export interface IFieldEmit {
  id: string;
  name: string | undefined;
  status: string | undefined;
}

@Component({
  selector: 'app-fields-edit-modal',
  templateUrl: './fields-edit-modal.component.html',
})
export class FieldEditModalComponent {
  @Output() onSave = new EventEmitter<IFieldEmit>();

  saving = false;
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    public modalRef: NzModalRef,
  ) {
    this.form = this.fb.group({
      id: [],
      name: ['', [Validators.required, Validators.maxLength(255)]],
      description: ['', [Validators.maxLength(255)]],
      friendlyName: ['', [Validators.maxLength(255)]],
      type: ['', [Validators.required]],
      indicatorIds: [[]],
    });

    this.form.controls.indicatorIds.valueChanges.subscribe(() => {

    });
  }

  initForm(
    id: string,
    name: string,
    status: string,
  ) {
    this.form.setValue({
      id,
      name,
      status,
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    this.saving = true;

    const formData = this.form.getRawValue();

    const emitData = {
      ...formData,
    } as IFieldEmit;

    this.onSave.emit(emitData);
  }
}
