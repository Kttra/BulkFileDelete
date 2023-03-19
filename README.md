# Bulk File Deleter

This program is designed to delete files from a specified directory. It can be run from the command line and accepts a number of options to customize its behavior.

## Quick Rundown

•  Deletes files from a specified directory

•  Can delete files based on file extention or name

•  Only deletes from specified path, not its subdirectories

•  Does not provide details on the files that were deleted (be careful to not delete something you don't want deleted)

•  The deleted file will be permanently deleted, it will not be sent to the recycling bin

•  Default options are .pfk, .wav, .mp4, .mov, and Add

•  Add option allows user to add an entry to the comboBox

## Usage

To start this program, simply run the exe file. You can select the desired file extention of the files you want to delete from the comboBox and enter the directory path. The program assumes you want to delete an extension if the selected option contains the character ".". Otherwise the program will assume you want to delete any file that contains the selected text (this is case sensitive).

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/226150833-39c1b814-6b1a-4dac-aaf1-099d79734a9d.png"><img>
</p>

## Adding Options to the ComboBox

To add options to the comboBox, simply select the "Add" option and press "Confirm".

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/226151186-d5d72a84-5692-41e1-ac97-e240603ffb55.png"><img>
</p>

An input form will appear for an additional entry.

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/226151154-0c876bbf-16d6-4b1a-8dfe-48df5967171a.png"><img>
</p>

## Examples of How this Program Works

If we have the directory set to "D:\Users\User\Videos\Compress" and we select ".wav" from the comboBox, all file types of ".wav" in the directory "D:\Users\User\Videos\Compress" will be deleted.

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/226151238-2260ce2b-a39f-4ebf-a294-b36761035720.png"><img>
</p>

If we have the directory set to "D:\Users\User\Videos\Compress" and we select "pic" from the comboBox, all file types that contain the text "pic" in its name will be deleted. This is case sensitive. Reminder that you can add different entries as options and "pic" is just an option.

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/226151280-616c64e2-6aa4-4399-863c-3e65a1b3dbc3.png"><img>
</p>

## License

This program is licensed under the GNU GENERAL PUBLIC LICENSE License. For more information, please see the `LICENSE` file.
