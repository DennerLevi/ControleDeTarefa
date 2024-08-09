import React, { useState } from 'react';
import BarraPesquisa from '../BarraPesquisa/BarraPesquisa';
import FormularioTarefa from '../FormularioTarefa/FormularioTarefa';
import './TelaPrincipal.css';

const TelaPrincipal = () => {
    const [showForm, setShowForm] = useState(false);
    const [tarefas, setTarefas] = useState([]);
    const [ordenacao, setOrdenacao] = useState('maisRecente');

    const handleFormOpen = () => setShowForm(true);
    const handleFormClose = () => setShowForm(false);

    const addTarefa = (tarefa) => {
        setTarefas([...tarefas, {...tarefa, dataCriacao: new Date()}]); // Assumindo que você adiciona uma data de criação
        handleFormClose();
    };

    const handleOrdenacao = (criterio) => {
        setOrdenacao(criterio);
    };

    const tarefasOrdenadas = tarefas.sort((a, b) => {
        return ordenacao === 'maisRecente' ? b.dataCriacao - a.dataCriacao : a.dataCriacao - b.dataCriacao;
    });

    return (
        <div className="container">
            <h1>Controle de Tarefas</h1>
            <BarraPesquisa onAddTask={handleFormOpen} />
            {showForm && <FormularioTarefa onAddTarefa={addTarefa} onClose={handleFormClose} />}
            {tarefas.length > 0 && (
                <>
                    <div className="sorting-controls">
                        <button onClick={() => handleOrdenacao('maisRecente')}>&#x25B2; Mais Recente</button>
                        <button onClick={() => handleOrdenacao('maisAntigo')}>&#x25BC; Mais Antigo</button>
                    </div>
                    <div className="results-area">
                        <div className="table-header">
                            <div className="table-cell">Título</div>
                            <div className="table-cell">Horas (SLA)</div>
                            <div className="table-cell">Arquivo</div>
                        </div>
                        {tarefasOrdenadas.map((tarefa, index) => (
                            <div key={index} className="table-row">
                                <div className="table-cell">{tarefa.title}</div>
                                <div className="table-cell">{tarefa.sla} horas</div>
                                <div className="table-cell">{tarefa.file ? tarefa.file.name : "Nenhum arquivo"}</div>
                            </div>
                        ))}
                    </div>
                </>
            )}
        </div>
    );
}

export default TelaPrincipal;
