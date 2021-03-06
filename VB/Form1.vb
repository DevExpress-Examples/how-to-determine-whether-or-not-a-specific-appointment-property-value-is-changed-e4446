﻿Imports System
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace SchedulerAppointmentPropertyChanged
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()

            Dim schedulerStorage As SchedulerStorage = schedulerControl1.Storage
            Dim apt As Appointment = schedulerStorage.CreateAppointment(AppointmentType.Normal)
            Dim baseTime As Date = Date.Today

            apt.Start = baseTime.AddHours(1)
            apt.End = baseTime.AddHours(2)
            apt.Subject = "Test"
            apt.Location = "Office"
            apt.Description = "Test procedure"

            schedulerStorage.Appointments.Add(apt)

            schedulerControl1.Start = baseTime
        End Sub

        Private Sub schedulerStorage1_AppointmentChanging(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs) Handles schedulerStorage1.AppointmentChanging
            Dim oldLabel As Object = CType(CType(e.Object, Appointment).GetSourceObject(DirectCast(sender, SchedulerStorageBase)), DataRowView).Row("Label")
            Dim newLabel As Object = CType(e.Object, Appointment).LabelKey

            If Not newLabel.Equals(oldLabel) Then
                MessageBox.Show("Label was changed!")
            End If
        End Sub
    End Class
End Namespace