### packaging system setup
```
(require 'package)                                                                                                    
(let* ((no-ssl (and (memq system-type '(windows-nt ms-dos))                                                           
                    (not (gnutls-available-p))))                                                                      
       (proto (if no-ssl "http" "https")))                                                                            
  ;; Comment/uncomment these two lines to enable/disable MELPA and MELPA Stable as desired                            
  (add-to-list 'package-archives (cons "melpa" (concat proto "://melpa.org/packages/")) t)                            
  ;;(add-to-list 'package-archives (cons "melpa-stable" (concat proto "://stable.melpa.org/packages/")) t)            
  (when (< emacs-major-version 24)                                                                                    
    ;; For important compatibility libraries like cl-lib                                                              
    (add-to-list 'package-archives '("gnu" . (concat proto "://elpa.gnu.org/packages/")))))                           
(package-initialize)  
```

###  neotree setup
```
(add-to-list 'load-path "/some/path/neotree")
(require 'neotree)
(global-set-key [f8] 'neotree-toggle)
```

### window numbering and navigating with M key
```
(require 'window-number)
(window-number-meta-mode)
```

### sublime text like scrolling buffer without cursor move
```
(defun gcm-scroll-down ()
    (interactive)
        (scroll-up 1))
	(defun gcm-scroll-up ()
	    (interactive)
	        (scroll-down 1))
		(global-set-key [(control down)] 'gcm-scroll-down)
		(global-set-key [(control up)] 'gcm-scroll-up)
```

### sublime like multiple cursors
```
(require 'multiple-cursors)
(global-set-key (kbd "C-l") 'mc/edit-lines)
(global-set-key (kbd "C-d") 'mc/mark-next-like-this)
(global-set-key (kbd "C-S-d") 'mc/mark-previous-like-this)
(global-set-key (kbd "C-c a") 'mc/mark-all-like-this)
```

### move all backup files (/.*~$/) out of source files
```
(setq backup-directory-alist '(("." . "~/.emacs.d/backups")))
```

### switch magic (tabs+spaces) identation off
```
(global-set-key (kbd "TAB") 'self-insert-command)
(setq-default indent-tabs-mode nil)
(setq-default tab-width 4)
(setq indent-line-function 'insert-tab)
(global-set-key (kbd "<backtab>") 'un-indent-by-removing-4-spaces)
(defun un-indent-by-removing-4-spaces ()
    "remove 4 spaces from beginning of of line"
    (interactive)
    (save-excursion
         (save-match-data
              (beginning-of-line)
              ;; get rid of tabs at beginning of line
              (when (looking-at "^\\s-+")
                  (untabify (match-beginning 0) (match-end 0))
              )
              (when (looking-at "^ ")
                  (replace-match "")
              )
         )
    )
)
```

`.bashrc`
```bash
alias emacs="emacs -nw"
alias emacs24="emacs -nw"
```
