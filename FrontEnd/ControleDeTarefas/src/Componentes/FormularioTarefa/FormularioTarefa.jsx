import React, { useState } from 'react';
import './FormularioTarefa.css';

const FormularioTarefa = ({ onAddTarefa, onClose }) => {
    const [title, setTitle] = useState('');
    const [sla, setSla] = useState('');
    const [file, setFile] = useState(null);

    const handleSubmit = (event) => {
        event.preventDefault();
        onAddTarefa({ title, sla, file }); // Passa a nova tarefa para o método onAddTarefa
        setTitle('');
        setSla('');
        setFile(null);
    };

    return (
        <div className="modal show">
            <div className="modal-content">
                <span className="close" onClick={onClose}>&times;</span>
                <h2 className="modal-title">Adicionando Tarefa</h2>
                <form onSubmit={handleSubmit}>
                    <label htmlFor="title">Título</label>
                    <input type="text" id="titleModal" name="title" value={title} onChange={(e) => setTitle(e.target.value)} required />

                    <label htmlFor="sla">SLA (em horas)</label>
                    <input type="number" id="slaModal" name="sla" value={sla} onChange={(e) => setSla(e.target.value)} required />

                    <label htmlFor="file">Upload de Arquivo</label>
                    <input type="file" id="fileModal" name="file" onChange={(e) => setFile(e.target.files[0])} required />

                    <button type="submit">Salvar</button>
                </form>
            </div>
        </div>
    );
}

export default FormularioTarefa;
