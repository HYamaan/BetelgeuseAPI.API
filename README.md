Master: Canlıda client tarafında kullanılan sürüm.

Dev/Development: Developer tarafında geliştirmeleri tamamlanmış özelliklerin tutulduğu branch’dir.

Hotfix: Canlıda olabilecek hataların çözümü için oluşturulan branchdir. Prod branch’imiz hangisi ise -ki bizde bu master veya main- branch’inden alınması gerekir.

Feature: Yeni bir özellik için oluşturulan branch’tir. Geliştirme tamamlandıktan sonra Pull Request ile Dev/Development branch’i ile birleştirilir.

Uygulamaya yazılan her geliştirme dev veya development branch’den alınarak feature/branch-adi standartına uyarak açmamız gerekmektedir. Branch açarken bu standartımıza özen gösterelim. Şuan bu şekilde açılmayan çok fazla branchlerimiz var.

Canlı da hata çıktı ve benim dev branch’im de canlıya çıkmaması gereken geliştirmelerim var. Bu durumda master’ dan yeni bir branch oluşturulup hotfix/bug-adi standartına uyarak açmamız gerekmektedir. Hotfix yapıldıktan sonra hem master hem dev branch’ ine almayı unutmamalıyız.
