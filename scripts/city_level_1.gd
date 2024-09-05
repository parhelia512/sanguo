extends Node2D

var messageScene = preload("res://scenes/game_state.tscn")

func _on_czkf_meta_clicked(meta: Variant) -> void:
	$Level1Open.show()

func _on_close_pressed() -> void:
	$Level1Open.hide()

# 土地开垦
func _on_tdkk_meta_clicked(meta: Variant) -> void:
	if(!limit_message()):
		return
	# 获取人物角色的内政属性
	var politics = Global.characters[Global.curr_city_character].attrs.politics
	# 获取当前城市的属性并修改
	var add_nong = 10
	if(politics > 60):
		add_nong = (politics - 50)
	Global.citys[Global.cur_city].nong += add_nong
	# 界面数据修改
	var message = messageScene.instantiate()
	$".".add_child(message)
	message.show_message("[color=#ffde66][center]" + Global.citys[Global.cur_city].name + "的农业增加了 " + str(add_nong) + " 点", Vector2(10, 10), message.Direction.Down, 1, 2)
	SignalBus.emit_signal("show_city_info", Global.citys[Global.cur_city].name, Global.cur_city)
	SignalBus.emit_signal("change_polities_times")

# 鼓励工商
func _on_glgs_meta_clicked(meta: Variant) -> void:
	if(!limit_message()):
		return
	# 获取人物角色的内政属性
	var politics = Global.characters[Global.curr_city_character].attrs.politics
	# 获取当前城市的属性并修改
	var add_shang = 10
	if(politics > 60):
		add_shang = (politics - 50)
	Global.citys[Global.cur_city].shang += add_shang
	# 界面数据修改
	var message = messageScene.instantiate()
	$".".add_child(message)
	message.show_message("[color=#ffde66][center]" + Global.citys[Global.cur_city].name + "的商业增加了 " + str(add_shang) + " 点", Vector2(10, 10), message.Direction.Down, 1, 2)
	SignalBus.emit_signal("show_city_info", Global.citys[Global.cur_city].name, Global.cur_city)
	SignalBus.emit_signal("change_polities_times")

# 市集开发
func _on_sjkf_meta_clicked(meta: Variant) -> void:
	if(!limit_message()):
		return
	# 获取人物角色的内政属性
	var politics = Global.characters[Global.curr_city_character].attrs.politics
	# 获取当前城市的属性并修改
	var add_ren = 1000
	if(politics > 60):
		add_ren += (politics - 50) * 30
	Global.citys[Global.cur_city].ren += add_ren
	# 界面数据修改
	var message = messageScene.instantiate()
	$".".add_child(message)
	message.show_message("[color=#ffde66][center]" + Global.citys[Global.cur_city].name + "的人口增加了 " + str(add_ren) + " 点", Vector2(10, 10), message.Direction.Down, 1, 2)
	SignalBus.emit_signal("show_city_info", Global.citys[Global.cur_city].name, Global.cur_city)
	SignalBus.emit_signal("change_polities_times")

# 情报收集
func _on_qbsj_meta_clicked(meta: Variant) -> void:
	if(!limit_message()):
		return
	# 获取这个年份这个城市的出仕武将
	# 获取到当前选择的武将的德数据
	# 根据德属性去做以下
		# 这个城市有未出仕武将
			# 如果德大于70，直接找到随机的一个
			# 如果德小于 70，概率减少
		# 这个城市没有未出仕武将
			# 根据德去获取金、量随机的一个值
	# 这里不能包含已经出仕的武将
	var jiang = Global.findAllCharacters(Global.cur_city, Global.citys[Global.cur_city].jiang, Global.year)
	var select_jiang = Global.get_array_diff(Global.citys[Global.cur_city].curent_jiang, jiang)
	var morality = Global.characters[Global.curr_city_character].attrs.morality
	if(select_jiang.size() > 0):
		if(morality >= 70):
			var index = randi() % select_jiang.size()
			var random_jiang = select_jiang[index]
			var message = messageScene.instantiate()
			$".".add_child(message)
			message.show_message("[color=#ffde66][center]" + Global.citys[Global.cur_city].name + "的 " + Global.characters[random_jiang].name + " 出仕了", Vector2(10, 10), message.Direction.Down, 1, 2)
			Global.citys[Global.cur_city].curent_jiang.append(random_jiang)
		elif(morality < 70):
			get_qbsj(morality)
	else:
		get_qbsj(morality)
	SignalBus.emit_signal("show_city_info", Global.citys[Global.cur_city].name, Global.cur_city)
	SignalBus.emit_signal("change_polities_times")
	# TODO: 此处是侦察功能
	# SignalBus.emit_signal("hide_city_message")
	# Global.is_show_other_city_message = true

# 没有出仕人物时候的逻辑
func get_qbsj(morality):
	var random_result = [
		{ "text": '富商捐赠金币', "type": 'jin' },
		{ "text": '富商捐赠粮草', "type": 'liang' },
		{ "text": '一无所获', "type": 'none' },
		{ "text": '一无所获', "type": 'none' },
	]
	var index = randi() % random_result.size()
	var random_result_item = random_result[index]
	if(random_result_item.type == 'none'):
		var message = messageScene.instantiate()
		$".".add_child(message)
		message.show_message("[color=#ffde66][center]" + random_result_item.text, Vector2(10, 10), message.Direction.Down, 1, 2)
	else:
		Global.citys[Global.cur_city][random_result_item.type] += morality * 2
		var message = messageScene.instantiate()
		$".".add_child(message)
		message.show_message("[color=#ffde66][center]" + random_result_item.text, Vector2(10, 10), message.Direction.Down, 1, 2)

# 侦察
func _on_zc_meta_clicked(meta: Variant) -> void:
	if(!limit_message()):
		return

	# 获取这个年份这个城市的出仕武将
	# 获取到当前选择的武将的德数据
	# TODO: 此处是侦察功能
	# SignalBus.emit_signal("hide_city_message")
	# Global.is_show_other_city_message = true

func limit_message():
	if(Global.polities_times == 0):
		var message = messageScene.instantiate()
		$".".add_child(message)
		message.show_message("[color=#ffde66][center]没有政令了", Vector2(10, 10), message.Direction.Down, 1, 2)
		return false
	if(Global.curr_city_character == 0):
		var message = messageScene.instantiate()
		$".".add_child(message)
		message.show_message("[color=#ffde66][center]请在上方先点击一个人物角色", Vector2(10, 10), message.Direction.Down, 1, 2)
		return false
	return true
