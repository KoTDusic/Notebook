using System.Collections.Generic;

namespace CommonInformation
{
    public static class LanguageDictionary
    {
        private static Dictionary<string, string> dictionary=new Dictionary<string, string>();

        static LanguageDictionary()
        {
            
            dictionary.Add("Remove", "Удалить");
            dictionary.Add("Edit", "Редактировать");
            dictionary.Add("Add", "Добавить");
            dictionary.Add("Close", "Закрыть");
            dictionary.Add("Ok", "ОК");
            dictionary.Add("Cancel", "Отмена");
            dictionary.Add("Confirmation", "Подтверждение операции");
            dictionary.Add("AddNote", "Добавление заметки");
            dictionary.Add("EditNote", "Редактирование заметки");
            dictionary.Add("Error", "Ошибка");
            dictionary.Add("InformationMessage", "Информационное сообщение");
            dictionary.Add("DateText", "Дата заметки:");
            dictionary.Add("Priority", "Приоритет задачи");
            dictionary.Add("LowPriority", "Низкий приоритет");
            dictionary.Add("MediumPriority", "Средний приоритет");
            dictionary.Add("HightPriority", "Высокий приоритет");
            dictionary.Add("NoteMessage", "Заметка:");
            dictionary.Add("MoveToArchive", "Переместить в архив");
            dictionary.Add("ArchiveView", "Представление архива. Нажмите, что бы перейти к задачам.");
            dictionary.Add("TasksView", "Представление задач. Нажмите, что бы перейти к архиву задач.");
            dictionary.Add("MoveFromArchive", "Восстановить из архива");
            dictionary.Add("DeleteNoteConfirmation", "Вы действительно хотите удалить выбранную запись?");
            dictionary.Add("ArchiveNoteConfirmation", "Вы действительно хотите отметить эту задачу как завершённую, и переместить эту её в архив?");
            dictionary.Add("UnarchiveNoteConfirmation", "Вы действительно хотите вернуть эту задачу из архива в список активных задач?");
            dictionary.Add("ArchiveNoteLastConfirmation", "Точно нигде не накосячила?");
            dictionary.Add("ArchiveNoteApproved", "Рада, ты восхитетельна!)");
            dictionary.Add("DeleteNoteException", "Ошибка удаления записи, текст ошибки:\n{0}");
            dictionary.Add("AddNoteException", "Ошибка добавления записи, текст ошибки:\n{0}");
            dictionary.Add("EditNoteException", "Ошибка редактирования записи, текст ошибки:\n{0}");
            dictionary.Add("ArchiveNoteException", "Ошибка добавления записи в архив, текст ошибки:\n{0}");
            dictionary.Add("UnarchiveNoteException", "Ошибка восстановления записи из архива, текст ошибки:\n{0}");
            dictionary.Add("EditNoteInputError", "Не удалось получить заметку для редактирования");
            dictionary.Add("DeleteNoteOperationInputError", "Неккоректные входные данные в операции Delete");
            dictionary.Add("DeleteNoteOperationUnknownError", "Не удалось удалить запись с id = {0}");
            dictionary.Add("AddNoteOperationInputDataError", "Неккоректные входные данные в операции Insert");
            dictionary.Add("AddNoteOperationUnknownError", "Ошибка, данные не добавлены в базу");
            dictionary.Add("UpdateNoteOperationInputDataError", "Неккоректные данные в операции Update");
            dictionary.Add("UpdateNoteOperationUnknownError", "Ошибка, данные не обновлены");
            dictionary.Add("GetNoteOperationInputError", "Неккоректные входные данные в операции Get");
            dictionary.Add("GetNoteOperationUnknownError", "Не найдено записи с id={0}");

        }

        public static string GetValue(string key)
        {
            string result;
            if (!dictionary.TryGetValue(key, out result))
            {
                result = string.Format("ERROR, key:({1}), not found", key);
            }
            return result;
        }
        public static string GetFormatValue(string key, params object[] items)
        {
            string result;
            if (!dictionary.TryGetValue(key, out result))
            {
                result = string.Format("ERROR, key:({1}), not found", key);
            }
            return string.Format(result, items);
        }
    }
}
