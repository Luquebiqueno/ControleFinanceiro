import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NotifierComponent } from '../modules/notifier/notifier/notifier.component';

@Injectable({
    providedIn: 'root'
})
export class NotifierService {

    constructor(private snackBar: MatSnackBar) { }

    showNotification(displayMessage: string, buttonText: string, messageType: string) {
        this.snackBar.openFromComponent(NotifierComponent, {
            data: {
                message: displayMessage,
                buttonText: buttonText
            },
            duration: 5000,
            horizontalPosition: 'center',
            verticalPosition: 'top',
            panelClass: messageType
        });
    }
}
