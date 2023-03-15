import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { map, take } from 'rxjs/operators';
import { ConfirmDialogComponent } from '../modals/confirm-dialog/confirm-dialog.component';

@Injectable({
  providedIn: 'root'
})
export class ConfirmService {
  BsModalRef?: BsModalRef<ConfirmDialogComponent>;

  constructor(private modalService: BsModalService) { }

  confirm(
    title = 'Confirmation',
    message = 'are you sure you want to do this?',
    btnOkText = 'Ok',
    btnCancelText = 'Cancel'
  ){
    const config = {
      initialState: {
        title,
        message,
        btnOkText,
        btnCancelText
      }
    }
    this.BsModalRef = this.modalService.show(ConfirmDialogComponent, config);
    return this.BsModalRef.onHidden!.pipe(
      map(() => {
        return this.BsModalRef!.content!.result
      }))
  }
}
