import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { HomePage } from './components/Home/HomePage';
import { FindAppointment } from './components/Appointments/FindAppointment';
import { BookAppointment } from './components/Appointments/BookAppointment';
import { CustomerLookup } from './components/Appointments/CustomerLookup';
import { CustomerAppointmentList } from './components/Appointments/CustomerAppointmentList';
import { EditAppointment } from './components/Appointments/EditAppointment';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route index element={<HomePage />} />
        <Route path="/appointments" element={<FindAppointment />} />
        <Route path="/appointments/book" element={<BookAppointment />} />
        <Route path="/appointments/view/customer">
          <Route index element={<CustomerLookup />} />
          <Route path=":id" element={<CustomerAppointmentList />} />
        </Route>
        <Route path="/appointments/edit">
          <Route path=":id" element={<EditAppointment />} />
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
